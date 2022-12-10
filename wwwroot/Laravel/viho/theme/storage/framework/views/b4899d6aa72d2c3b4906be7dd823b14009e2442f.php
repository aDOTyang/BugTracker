<?php $__env->startSection('title'); ?>Knob Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Knob Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">Knob Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Clock</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center knob-chart">
							<div class="chart-clock-main">
								<div class="clock-large">
									<input class="knob hour" data-min="0" data-max="24" data-bgcolor="#eeeeee" data-fgcolor="#24695c" data-displayinput="false" data-width="300" data-height="300" data-thickness=".2" />
								</div>
								<div class="clock-medium">
									<input class="knob minute" data-min="0" data-max="60" data-bgcolor="#eeeeee" data-fgcolor="#ba895d" data-displayinput="false" data-width="200" data-height="200" data-thickness=".20" />
								</div>
								<div class="clock-small">
									<input class="knob second" data-min="0" data-max="60" data-bgcolor="#eeeeee" data-fgcolor="#222222" data-displayinput="false" data-width="100" data-height="100" data-thickness=".2" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Tron</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-width="295" data-height="295" data-angleoffset="180" data-fgcolor="#24695c" data-skin="tron" data-thickness=".1" value="35" />
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 xl-50 col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Angle Offset</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-width="200" data-thickness=".1" data-angleoffset="90" data-fgcolor="#24695c" data-linecap="round" value="35" />
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 xl-50 col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Disable Display Input</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-width="200" data-thickness=".1" data-fgcolor="#24695c" data-displayinput="false" value="35" />
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 xl-50 col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Cursor Mode</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-width="200" data-cursor="true" data-fgcolor="#24695c" data-thickness=".1" value="29" />
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 xl-50 col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Display Previous Value</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-width="200" data-thickness=".1" data-fgcolor="#24695c" data-min="-100" data-displayprevious="true" value="44" />
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 xl-50 col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Angle Offset & Arc</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-angleoffset="-125" data-anglearc="250" data-fgcolor="#24695c" data-thickness=".1" data-rotation="anticlockwise" value="35" />
						</div>
					</div>
				</div>
			</div>
			<div class="col-xl-4 xl-50 col-sm-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>4-digit, step 0.1</h5>
					</div>
					<div class="card-body">
						<div class="knob-block text-center">
							<input class="knob" data-min="-10000" data-thickness=".1" data-fgcolor="#24695c" data-displayprevious="true" data-max="10000" data-step=".1" value="0" />
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/knob/knob.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/knob/knob-chart.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chart-knob.blade.php ENDPATH**/ ?>