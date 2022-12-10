<?php $__env->startSection('title'); ?>Google Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Google Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">Google Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-12 col-xl-4 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Pie Chart <span class="digits">1</span></h5>
					</div>
					<div class="card-body p-0 chart-block">
						<div class="chart-overflow" id="pie-chart4"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-4 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Area Chart <span class="digits">1</span></h5>
					</div>
					<div class="card-body p-0 chart-block">
						<div class="chart-overflow" id="area-chart1"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-4 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Area Chart <span class="digits">2</span></h5>
					</div>
					<div class="card-body p-0 chart-block">
						<div class="chart-overflow" id="area-chart2"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-4 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Pie Chart <span class="digits">2</span></h5>
					</div>
					<div class="card-body p-0 chart-block">
						<div class="chart-overflow" id="pie-chart1"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-4 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Pie Chart <span class="digits">3</span></h5>
					</div>
					<div class="card-body p-0 chart-block">
						<div class="chart-overflow" id="pie-chart2"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-4 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Pie Chart <span class="digits">4</span></h5>
					</div>
					<div class="card-body p-0 chart-block">
						<div class="chart-overflow" id="pie-chart3"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Column Chart <span class="digits">1 </span></h5>
					</div>
					<div class="card-body chart-block">
						<div class="chart-overflow" id="column-chart1"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header">
						<h5>Column Chart <span class="digits">2</span></h5>
					</div>
					<div class="card-body chart-block">
						<div class="chart-overflow" id="column-chart2"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header">
						<h5>Gantt Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="chart-overflow" id="gantt_chart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header">
						<h5>Line Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="chart-overflow" id="line-chart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header">
						<h5>Combo Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="chart-overflow" id="combo-chart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-12">
				<div class="card">
					<div class="card-header">
						<h5>bar-chart2</h5>
					</div>
					<div class="card-body chart-block">
						<div id="bar-chart2"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-12">
				<div class="card">
					<div class="card-header">
						<h5>word tree</h5>
					</div>
					<div class="card-body chart-block">
						<div class="word-tree" id="wordtree_basic"></div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/google/google-chart-loader.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/google/google-chart.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chart-google.blade.php ENDPATH**/ ?>